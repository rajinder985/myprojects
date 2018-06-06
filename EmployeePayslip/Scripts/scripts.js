function jQueryAjaxPost(form)
{
	$.validator.unobtrusive.parse(form);
	var formdata = new FormData($('form').get(0));
	if($(form).valid())
	{
		var employeModel = { FirstName: '', LastName: '', GrossIncome: '', SuperRate: '', PayPeriod: '' }

		employeModel.FirstName   = form[1].value;
		employeModel.LastName	 = form[2].value
		employeModel.GrossIncome = form[3].value
		employeModel.SuperRate   = form[4].value
		employeModel.PayPeriod = form[5].value
		jQuery("#loaderImage").show();
		$.ajax(
			{   type: "POST",
				async: false,
				url: "/EmployeeSalary/GenerateSalary",
				data: employeModel,
				context: document.body,
				success: function (response) {
					window.setTimeout(function () {
						$("#secondTab").html(response);
						jQuery("#loaderImage").hide();
						$("#secondTab").show();
					}, 350);					
					
									
				},
				error: function (e) {
					alert("Something went wrong. Please try again");
				}
			});

	}
	return false;
}

$(document).ready(function () {	
	Reset();
});


function Reset()
{
	$(".datefield").datepicker();
	$("input[type=text], textarea").val("");
	$("#secondTab").hide();
	$('#PayPeriod').val("").datepicker("clearDates");
}