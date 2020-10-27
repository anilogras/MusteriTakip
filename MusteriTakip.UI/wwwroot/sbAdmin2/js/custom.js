



$(document).ready(function () {



    //Global Ayarlar 
    function tabloDuzenle() {
        if ($("table tbody tr").length === 0) {
            var baslikAdeti = $("table thead tr th").length;
            $("table tbody").html(`<tr> <td colspan="${baslikAdeti}"><p class="text-center">Kayıt Bulunamadı</p></td></tr>`)
        }
    }

    $(document).on("update", function () {
      
        tabloDuzenle();
    })

    tabloDuzenle();

    $(document).on('hidden.bs.modal', function (e) {
        $(".modal-backdrop").remove();
    })

    if ($(".ajax-errors li").length === 0) {
        $(".ajax-errors").hide();
    }

    if ($('.il').length) {
        $.ajax({
            url: "/Il/IlGetir",
            type: "get",
            success: function (data) {
                var parseData = JSON.parse(data);
                $('.il').empty();
                $('.il').append(`<option value="0">İL SEÇİN</option>`)
                $.each(parseData, function (i, value) {
                    $('.il').append(`<option value="${value.Id}">${value.Sehir}</option>`)
                })
            }
        })
    }

    if ($('.yetkiler').length) {
        $.ajax({
            url: "/Yetki/YetkiGetir",
            type: "Get",
            success: function (data) {
                var parseData = JSON.parse(data);

                $.each(parseData, function (i, value) {
                    $('.yetkiler').append(`<div class="col-sm-12 form-input-content mb-1"><input type="checkbox" class="checkbox" name="Roller[][Name]" value="${value.Name}" /><label>${value.RolAdi}</label></div>`);
                })
            }
        })
    }

    $(document).on("change", ".il", function () {

        var ilceSelect = $(this).parents(".form-input-content").find(".ilce");

        $.ajax({
            url: "/Il/IlceGetir/" + $(this).val(),
            type: "get",
            success: function (data) {
                var parseData = JSON.parse(data);
                $(ilceSelect).empty();
                $(ilceSelect).append(`<option value="0">İLÇE SEÇİN</option>`)
                $.each(parseData, function (i, value) {
                    $(ilceSelect).append(`<option value="${value.Id}">${value.IlceAdi}</option>`)
                })
            } 
        })

    })

    $(document).on('click', '.copy-content', function () {

        var copyContent = $(this).parents('.form-input-content').clone();
        $(copyContent).find(":input").val('');
        $(copyContent).find("select option[value='0']").prop("selected", "selected");

        $(this).parents(".form-group").append(copyContent);

    })


    //Pagination Js Kodları
    $(document).on("click", '.ajax-pagination li a ', function () {
        var sendUrl = $(this).closest('.ajax-pagination').data("url");
        var pageNo = $(this).data("page");
        var query = $(this).data("query");
        var lastUrl = sendUrl + pageNo + query;
        $.ajax({
            url: lastUrl,
            success: function (html) {
                $('.ajax-table').empty();
                $('.ajax-table').html(html);
                window.location.hash = (pageNo + query).replace('#', '');
            }
        })
    })


    //Input Kopyalama
    $(document).on("click", '.form-input-copy', function () {
        var content = $(this).parent().siblings(".form-input-content").first().clone(false);
        $(content).find(":input").val('');
        $(content).find("select option[value='0']").prop("selected", "selected");
        $(content).find(".ilce :not(option[value='0'])").remove();
        $(this).parent().before(content);
    })

    //input silme
    $(document).on("click", '.remove-content', function () {
        var formGroup = $(this).parents(".form-group");
        if ($(formGroup).children('.form-input-content').length > 1) {
            $(this).parents('.form-input-content').remove();
        }
    })


    $(document).on("click", '.submit-btn', function () {

        var submitButton = $(this);
        var formContent = $(submitButton).parents('.ajax-form');
        var postUrl = $(submitButton).parents(".modal").data("post-url");
       
        var serializeData = $(formContent).find(':input').filter(function () {
            return $.trim(this.value).length > 0
        }).serializeJSON();

        formContent.find(":input:not(radio)").val('');
        formContent.find("select option[value='0']").attr("selected", "selected");

        $.ajax({
            type:"Post",
            url: postUrl,
            data: { ajaxData: serializeData },
            success: function (data) {

                $(".ajax-table").empty();
                $(".ajax-table").html(data);
                $(document).trigger("update");
                $(submitButton).parents(".modal").modal("hide");
                alertify.success("İşlem Başarılı");
            },
            error: function (errorData) {
                switch (errorData.status) {
                    case 500:
                        console.log(errorData.status);
                        console.log(errorData.responseText);
                        $('.modal-container').modal('hide');
                        alertify.error('Server Kaynaklı Bir Hata Oluştu. Lütfen Daha Sonra Tekrar Deneyin ...');
                        break;

                    case 400:
                        var serializeData = JSON.parse(errorData.responseText);
                        var liElement = "";
                        $.each(serializeData, function (i, value) {
                            liElement += `<li> ${value} </li>`
                        })
                        $('.ajax-errors').append(liElement).show();
                        $(submitButton).parent(".modal").scrollTop(0);
                        alertify.error('Hata Oluştu . Lütfen Hataları Konrol Edin.');
                        break;

                    default:
                        console.log(errorData.responseText);
                        alertify.error('Bilinmeyen Bir Hata Oluştu. Lütfen Daha Sonra Tekrar Deneyin ...');
                        break;
                }

            }
        })



    })

    $('.modal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var url = button.data('post-url');
        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
        var modal = $(this);
        modal.attr("data-post-url", url);
    })

    $('#fisDetay').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var fisID = button.data("fis-id");
        var modal = $(this);

        modal.find(".modal-body").html('<p class="text-center">Fiş Yükleniyor</p>')

        $.ajax({
            url: "/Fis/FisDetay/" + fisID,
            type:"Get",
            success: function (data) {
                kdvGetir();
                modal.find(".modal-body").empty();
                modal.find(".modal-body").html(data);
            },
            error: function (error) {
                console.log(error.responseText);
            }
        })

    })

    $(document).on('show.bs.modal', '#fisSil', function (event) {

        var button = $(event.relatedTarget);
        var url = button.data("post-url");
        var fisNo = button.data("fis-no");
        var modal = $(this);

        modal.find("#delete").attr("data-url", url);
        modal.find("#fisNo").empty().text(fisNo)
    })

    $(document).on('show.bs.modal', '#cariSil', function (event) {

        var button = $(event.relatedTarget);
        var url = button.data("post-url");
        var ad = button.data("cari-adi");
        var modal = $(this);

        modal.find("#delete").attr("data-url", url);
        modal.find("#cariAdi").empty().text(ad)
    })

    $(document).on('show.bs.modal', '#kullaniciSil', function (event) {

        var button = $(event.relatedTarget);
        var url = button.data("post-url");
        var ad = button.data("kullanici-adi");
        var modal = $(this);

        modal.find("#delete").attr("data-url", url);
        modal.find("#kullaniciAdi").empty().text(ad)
    })

    $(document).on('click', '#delete', function () {

        var button = $(this);
        var postUrl = button.data('url');

        $.ajax({
            url: postUrl,
            type: "Get",
            success: function (data) {
                $(".ajax-table").empty();
                $(".ajax-table").html(data);
               
             
                $('.modal-delete').modal('hide');
                $('.modal-backdrop').remove();
                $(document).trigger("update");
                alertify.success("İşlem Başarılı");
            },
            error: function (errorData) {
                switch (errorData.status) {
                    case 500:
                        console.log(errorData.status);
                        console.log(errorData.responseText);
                        $('.modal-delete').modal('hide')
                        alertify.error('Server Kaynaklı Bir Hata Oluştu. Lütfen Daha Sonra Tekrar Deneyin ...');
                        break;

                    case 400:
                        var serializeData = JSON.parse(errorData.responseText);
                        var liElement = "";
                        $.each(serializeData, function (i, value) {
                            liElement += `<li> ${value} </li>`
                        })
                        $('.ajax-errors').append(liElement).show();
                        $(submitButton).parent(".modal").scrollTop(0);
                        alertify.error('Hata Oluştu . Lütfen Hataları Konrol Edin.');
                        break;

                    default:
                        console.log(errorData.responseText);
                        alertify.error('Bilinmeyen Bir Hata Oluştu. Lütfen Daha Sonra Tekrar Deneyin ...');
                        break;
                }

            }
        })

    })
    

})