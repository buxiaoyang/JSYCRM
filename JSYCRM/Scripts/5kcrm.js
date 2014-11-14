function changeCondition(){
	var a = $("#field option:selected").attr('class');
	var b = $("#field option:selected").val();
	var c = $("#field option:selected").attr('rel');

	if(a == 'number') {
		$("#conditionContent").html('<select id="condition" style="width:auto" name="condition" onchange="changeSearch()">'
							+'<option value="gt">  '+CrmLang.GT+'  </option>'
							+'<option value="lt">  '+CrmLang.LT+'  </option>'
							+'<option value="eq">  '+CrmLang.EQ+'  </option>'
							+'<option value="neq">  '+CrmLang.NEQ+'  </option>'
							+'</select>&nbsp;&nbsp; ');
		$("#searchContent").html('<input id="search" type="text" class="input-medium search-query" name="search"/>&nbsp;&nbsp;');
	} else if ((a == 'word') || (a == 'text') || (a == 'textarea') || (a == 'editor')) {
		$("#conditionContent").html('<select id="condition" style="width:auto" name="condition" onchange="changeSearch()">'
							+'<option value="contains">'+CrmLang.CONTAINS+'</option>'
							+'<option value="not_contain">'+CrmLang.NOT_CONTAIN+'</option>'
							+'<option value="is">'+CrmLang.IS+'</option>'
							+'<option value="isnot">'+CrmLang.ISNOT+'</option>'							
							+'<option value="start_with">'+CrmLang.START_WITH+'</option>'
							+'<option value="end_with">'+CrmLang.END_WITH+'</option>'
							+'<option value="is_empty">'+CrmLang.IS_EMPTY+'</option>'
							+'<option value="is_not_empty">'+CrmLang.IS_NOT_EMPTY+'</option></select>&nbsp;&nbsp;');
		$("#searchContent").html('<input id="search" type="text" class="input-medium search-query" name="search"/>&nbsp;&nbsp;');
	} else if (a == 'date' || a== 'datetime') {
		$("#conditionContent").html('<select id="condition" style="width:auto" name="condition" onchange="changeSearch()">'
							+'<option value="tgt">  '+CrmLang.BEHIND+'  </option>'
							+'<option value="lt">  '+CrmLang.BEFORE+'  </option>'
							+'<option value="between">  '+CrmLang.EXIST+'  </option>'
							+'<option value="nbetween">  '+CrmLang.ABSENT+'  </option>'
							+'</select>&nbsp;&nbsp;');
		$("#searchContent").html('<input id="search" type="text" class="input-medium search-query" name="search" onclick="WdatePicker()"/>&nbsp;&nbsp;');
	} else if (a == 'bool') {
		$("#conditionContent").html('<select id="condition" style="width:auto" name="condition" onchange="changeSearch()">'
							+'<option value="1">'+CrmLang.IS+'</option>'
							+'<option value="0">'+CrmLang.ISNOT+'</option>'
							+'</select>&nbsp;&nbsp;');
		$("#searchContent").html('<input id="search" type="text" class="input-medium search-query" name="search"/>&nbsp;&nbsp;');
	} else if (a == 'sex') {
		$("#searchContent").html('<select id="search" style="width:auto" name="search">'
							+'<option value="1">'+CrmLang.MAN+'</option>'
							+'<option value="0">'+CrmLang.WOMAN+'</option>'
							+'</select>&nbsp;&nbsp;');
		$("#conditionContent").html('');
	} else if (a == 'saltname') {
		$("#searchContent").html('<select id="search" style="width:auto" name="search">'
							+'<option value='+CrmLang.LADY+'>'+CrmLang.LADY+'</option>'
							+'<option value='+CrmLang.SIR+'>'+CrmLang.SIR+'</option>'
							+'<option value='+CrmLang.TEACHER+'>'+CrmLang.TEACHER+'</option>'
							+'<option value='+CrmLang.DOCTOR+'>'+CrmLang.DOCTOR+'</option>'
							+'<option value='+CrmLang.DOCTORS+'>'+CrmLang.DOCTORS+'</option>'
							+'<option value='+CrmLang.PROFESSOR+'>'+CrmLang.PROFESSOR+'</option>'
							+'</select>&nbsp;&nbsp;');
		$("#conditionContent").html('');
	} else if (a == 'source') {
		$.ajax({
			type:'get',
			url:'index.php?m=setting&a=getsourcelist',
			async:false,
			success:function(data){
				options = '';
				$.each(data.data, function(k, v){
					options += '<option value="'+v.source_id+'">'+v.name+'</option>';
				});

				$("#searchContent").html('<select id="search" style="width:auto" name="search">' + options + '</select>&nbsp;&nbsp;');
				$("#conditionContent").html('');
			},
			dataType:'json'
		});	
	} else if (a == 'leads_status') {
		$("#searchContent").html('<select id="search" style="width:auto" name="search">'
							+'<option value='+CrmLang.TRY_TO_CONTACT+'>'+CrmLang.TRY_TO_CONTACT+'</option>'
							+'<option value='+CrmLang.CONTACT_IN_THE_FUTURE+'>'+CrmLang.CONTACT_IN_THE_FUTURE+'</option>'
							+'<option value='+CrmLang.ALREADY_CONTACTED+'>'+CrmLang.ALREADY_CONTACTED+'</option>'
							+'<option value='+CrmLang.FALSE_CLUES+'>'+CrmLang.FALSE_CLUES+'</option>'
							+'<option value='+CrmLang.MISSING_CLUES+'>'+CrmLang.MISSING_CLUES+'</option>'
							+'</select>&nbsp;&nbsp;');
		$("#conditionContent").html('');
	} else if (a == 'industry') {
		$.ajax({
			type:'get',
			url:'index.php?m=setting&a=getindustrylist',
			async:false,
			success:function(data){
				options = '';
				$.each(data.data, function(k, v){
					options += '<option value="'+v.industry_id+'">'+v.name+'</option>';
				});

				$("#searchContent").html('<select id="search" style="width:auto" name="search">' + options + '</select>&nbsp;&nbsp;');
				$("#conditionContent").html('');
			},
			dataType:'json'
		});	
	} else if (a == 'leads_rating') {
		$("#searchContent").html('<select id="search" style="width:auto" name="search">'
							+'<option value='+CrmLang.WUXING+'>'+CrmLang.WUXING+'</option>'
							+'<option value='+CrmLang.SIXING+'>'+CrmLang.SIXING+'</option>'
							+'<option value='+CrmLang.SANXING+'>'+CrmLang.SANXING+'</option>'
							+'<option value='+CrmLang.ERXING+'>'+CrmLang.ERXING+'</option>'
							+'<option value='+CrmLang.YIXING+'>'+CrmLang.YIXING+'</option>'
							+'</select>&nbsp;&nbsp;');
		$("#conditionContent").html('');
	} else if (a == 'role') {
		$.ajax({
			type:'get',
			url:'index.php?m=user&a=getrolelist',
			async:false,
			success:function(data){
				options = '';
				$.each(data.data, function(k, v){
					options += '<option value="'+v.role_id+'">'+v.user_name+' ['+v.department_name+'-'+v.role_name+']</option>';
				});
				$("#searchContent").html('<select id="search" style="width:auto" name="search">' + options + '</select>&nbsp;&nbsp;');
				$("#conditionContent").html('');
			},
			dataType:'json'
		});		
	} else if (a == 'business_status') {
		$.ajax({
			type:'get',
			url:'index.php?m=setting&a=getbusinessstatuslist',
			async:false,
			success:function(data){
				options = '';
				$.each(data.data, function(k, v){
					options += '<option value="'+v.status_id+'">'+v.name+'</option>';
				});

				$("#searchContent").html('<select id="search" style="width:auto" name="search">' + options + '</select>&nbsp;&nbsp;');
				$("#conditionContent").html('');
			},
			dataType:'json'
		});		
	}  else if (a == 'leads_status') {
		$.ajax({
			type:'get',
			url:'index.php?m=setting&a=getleadsstatuslist',
			async:false,
			success:function(data){
				options = '';
				$.each(data.data, function(k, v){
					options += '<option value="'+v.status_id+'">'+v.name+'</option>';
				});

				$("#searchContent").html('<select id="search" style="width:auto" name="search">' + options + '</select>&nbsp;&nbsp;');
				$("#conditionContent").html('');
			},
			dataType:'json'
		});		
	} else if (a == 'customer') {
		$.ajax({
			type:'get',
			url:'index.php?m=customer&a=getcustomerlist',
			async:false,
			success:function(data){
				options = '';
				$.each(data.data, function(k, v){
					options += '<option value="'+v.customer_id+'">'+v.name+'</option>';
				});
				$("#searchContent").html('<select id="search" style="width:auto" name="search">' + options + '</select>&nbsp;&nbsp;');
				$("#conditionContent").html('');
			},
			dataType:'json'
		});		
	}else if (a == 'contacts') {
		$.ajax({
			type:'get',
			url:'index.php?m=contacts&a=getcontactslist',
			async:false,
			success:function(data){
				options = '';
				$.each(data.data, function(k, v){
					options += '<option value="'+v.contacts_id+'">'+v.name+'</option>';
				});
				$("#searchContent").html('<select id="search" style="width:auto" name="search">' + options + '</select>&nbsp;&nbsp;');
				$("#conditionContent").html('');
			},
			dataType:'json'
		});		
	} else if (a == 'contract') {
		$.ajax({
			type:'get',
			url:'index.php?m=contract&a=getcontractlist',
			async:false,
			success:function(data){
				options = '';
				$.each(data.data, function(k, v){
					options += '<option value="'+v.contract_id+'">'+v.number+'--'+v.customer_name+'</option>';
				});
				$("#searchContent").html('<select id="search" style="width:auto" name="search">' + options + '</select>&nbsp;&nbsp;');
				$("#conditionContent").html('');
			},
			dataType:'json'
		});		
	} else if(a=='all') {
		$("#conditionContent").html('<select id="condition" style="width:auto" name="condition" onchange="changeSearch()">'
							+'<option value="contains">'+CrmLang.CONTAINS+'</option>'
							+'<option value="is">'+CrmLang.IS+'</option>'
							+'<option value="start_with">'+CrmLang.START_WITH+'</option>'
							+'<option value="end_with">'+CrmLang.END_WITH+'</option>'
							+'<option value="is_empty">'+CrmLang.IS_EMPTY+'</option>'
							+'</select>&nbsp;&nbsp;');
		$("#searchContent").html('<input id="search" type="text" class="input-medium search-query" name="search"/>&nbsp;&nbsp;');
	} else if (a == 'task_status') {
		$("#conditionContent").html('<select id="search" style="width:auto" name="search">'
							+'<option value='+CrmLang.NOT_STARTED+'>'+CrmLang.NOT_STARTED+'</option>'
							+'<option value='+CrmLang.RETARDATION+'>'+CrmLang.RETARDATION+'</option>'
							+'<option value='+CrmLang.UNDERWAY+'>'+CrmLang.UNDERWAY+'</option>'
							+'<option value='+CrmLang.COMPLETED+'>'+CrmLang.COMPLETED+'</option>'
							+'</select>&nbsp;&nbsp;');
		$("#searchContent").html('');
	} else if (a == 'task_priority') {
		$("#conditionContent").html('<select id="search" style="width:auto" name="search">'
							+'<option value='+CrmLang.HIGH+'>'+CrmLang.HIGH+'</option>'
							+'<option value='+CrmLang.GENERAL+'>'+CrmLang.GENERAL+'</option>'
							+'<option value='+CrmLang.LOW+'>'+CrmLang.LOW+'</option>'
							+'</select>&nbsp;&nbsp;');
		$("#searchContent").html('');
	}else if (a == 'payables_status') {
		$("#conditionContent").html('<select id="search" style="width:auto" name="search">'
							+'<option value="0">'+CrmLang.NOT_PAYING+'</option>'
							+'<option value="1">'+CrmLang.PART_OF_THE_PREPAID+'</option>'
							+'<option value="2">'+CrmLang.ACCOUNT_PAID+'</option>'
							+'</select>&nbsp;&nbsp;');
		$("#searchContent").html('');
	}else if (a == 'order_status') {
		$("#conditionContent").html('<select id="search" style="width:auto" name="search">'
							+'<option value="0">'+CrmLang.NOT_CHECK+'</option>'
							+'<option value="1">'+CrmLang.HAS_THE_INVOICING+'</option>'
							+'</select>&nbsp;&nbsp;');
		$("#searchContent").html('');
	} else if (a == 'receivables_status') {
		$("#conditionContent").html('<select id="search" style="width:auto" name="search">'
							+'<option value="0">'+CrmLang.NOT_RECEIVE_PAYMENT+'</option>'
							+'<option value="1">'+CrmLang.PART_OF_THE_RECEIVED+'</option>'
							+'<option value="2">'+CrmLang.HAS_BEEN_RECEIVING+'</option>'
							+'</select>&nbsp;&nbsp;');
		$("#searchContent").html('');
	} else if (a == 'customer_ownership') {	
		$("#conditionContent").html('<select id="search" style="width:auto" name="search">'
							+'<option value='+CrmLang.HIGH+'>'+CrmLang.HIGH+'</option>'
							+'<option value='+CrmLang.NO+'>'+CrmLang.NO+'</option>'
							+'<option value='+CrmLang.STATE_OWNED_ENTERPRISES+'>'+CrmLang.STATE_OWNED_ENTERPRISES+'</option>'
							+'<option value='+CrmLang.FOREIGN_CAPITAL_ENTERPRISE+'>'+CrmLang.FOREIGN_CAPITAL_ENTERPRISE+'</option>'
							+'<option value='+CrmLang.PRIVATE_ENTERPRISE+'>'+CrmLang.PRIVATE_ENTERPRISE+'</option>'
							+'<option value='+CrmLang.COLLECTIVE_ENTERPRISE+'>'+CrmLang.COLLECTIVE_ENTERPRISE+'</option>'
							+'<option value='+CrmLang.JOINT_STOCK_COMPANY+'>'+CrmLang.JOINT_STOCK_COMPANY+'</option>'
							+'<option value='+CrmLang.JOINT_VENTURE+'>'+CrmLang.JOINT_VENTURE+'</option>'
							+'<option value='+CrmLang.SOLE_PROPRIETORSHIP_ENTERPRISE+'>'+CrmLang.SOLE_PROPRIETORSHIP_ENTERPRISE+'</option>'
							+'<option value='+CrmLang.OTHER+'>'+CrmLang.OTHER+'</option>'
							+'</select>&nbsp;&nbsp;');
		$("#searchContent").html('');
	} else if (a == 'customer_type') {	
		$("#conditionContent").html('<select id="search" style="width:auto" name="search">'
							+'<option value='+CrmLang.ANALYSTS+'>'+CrmLang.ANALYSTS+'</option>'
							+'<option value='+CrmLang.COMPETITOR+'>'+CrmLang.COMPETITOR+'</option>'
							+'<option value='+CrmLang.CUSTOMER+'>'+CrmLang.CUSTOMER+'</option>'
							+'<option value='+CrmLang.INTEGRATORS+'>'+CrmLang.INTEGRATORS+'</option>'
							+'<option value='+CrmLang.INVESTORS+'>'+CrmLang.INVESTORS+'</option>'
							+'<option value='+CrmLang.PARTNERS+'>'+CrmLang.PARTNERS+'</option>'
							+'<option value='+CrmLang.PUBLISHERS+'>'+CrmLang.PUBLISHERS+'</option>'
							+'<option value='+CrmLang.TARGET+'>'+CrmLang.TARGET+'</option>'
							+'<option value='+CrmLang.SUPPLIER+'>'+CrmLang.SUPPLIER+'</option>'
							+'<option value='+CrmLang.OTHER+'>'+CrmLang.OTHER+'</option>'
							+'</select>&nbsp;&nbsp;');
		$("#searchContent").html('');
	}else if (a == 'box') {
		$.ajax({
			type:'get',
			url:'index.php?m=setting&a=boxfield&model='+c+'&field='+b,
			async:false,
			success:function(data){
				options = '';
				$.each(data.data, function(k, v){
					options += '<option value="'+v+'">'+v+'</option>';
				});
				$("#searchContent").html('<select id="search" style="width:auto" name="search">' + options + '</select>&nbsp;&nbsp;');
                if(data.info == 'checkbox'){
                    $("#conditionContent").html('<input type="hidden" name="condition" value="contains">');
                }else{
                    $("#conditionContent").html('');
                }
			},
			dataType:'json'
		});		
	} else if (a == 'address') {
        $("#conditionContent").html('<select id="condition" style="width:auto" name="condition">'
							+'<option value="start_with">'+CrmLang.EXIST+'</option>'
							+'<option value="not_start_with">'+CrmLang.ABSENT+'</option></select>&nbsp;&nbsp;');
        $("#searchContent").html('<select name="state" id="state" style="width:auto"></select>'
							+'<select name="city" id="city" style="width:auto"></select>'
							+'<input type="text" id="search" name="search" placeholder='+CrmLang.STREET_INFORMATION+' class="input-large">&nbsp;&nbsp;');
        new PCAS("state","city","","");
	} 
}
function checkSearchForm() {
    search = $("#searchForm #search").val();
    field = $("#searchForm #field").val();
    if($("#searchForm #state").length>0){
        if($("#searchForm #state").val() == ''){
            alert(CrmLang.SELECT_REGION);return false;
        }
    }else{
        if (search == "") {
            alert(CrmLang.FILL_IN_THE_SEARCH_CONTENT);return false;
        }else if(field == ""){
			 alert(CrmLang.SELECT_FILTER_CONDITION);return false;
		}
    }
    return true;
}

function changeSearch() {
	a = $("#field option:selected").attr('class');
	b = $("#condition option:selected").val();
	if(b == 'is_empty' || b == 'is_not_empty') {
		$("#searchContent").html('');
	} else {
		if(a == "date") {
			$("#searchContent").html('<input id="search" type="text" class="input-medium search-query" name="search" onclick="WdatePicker()"/>&nbsp;&nbsp;');	
		}  else if (a == "number" || a == "word" || a == "date") {
			$("#searchContent").html('<input id="search" type="text" class="input-medium search-query" name="search"/>&nbsp;&nbsp;');
		}
	}
}
$(function(){
	if($('.table_thead_fixed thead').length>0){
		var b=30;
		var c=$(".table_thead_fixed").offset();
		var a=$(window).scrollTop();
		var default_w_width = $(window).width();
		var default_width = new Array();
		$.each($(".table_thead_fixed tbody tr:first td"),function(key,val){
			$('.table_thead_fixed thead tr:first th:eq('+key+')').width($(val).width());
			$(val).width($(val).width());
			default_width[key] = $(val).width();
		});
		if(a>c.top-b){
			$(".table_thead_fixed thead").addClass("fixed");
		}else{
			$(".table_thead_fixed thead").removeClass("fixed");
		};
		$(window).scroll(
			function(){
				var a=$(window).scrollTop();
				$.each($(".table_thead_fixed tbody tr:first td"),function(key,val){
					$('.table_thead_fixed thead tr:first th:eq('+key+')').width($(val).width());
					$(val).width($(val).width());
				});
				if(a>c.top-b){
					$(".table_thead_fixed thead").addClass("fixed");
				}else{
					$(".table_thead_fixed thead").removeClass("fixed");
				}
			}
		);
		$(window).resize(
			function(){
				$.each($(".table_thead_fixed tbody tr:first td"),function(key,val){
					if(default_w_width == $(window).width()){
						$(val).css({width:default_width[key]});
						$('.table_thead_fixed thead tr:first th:eq('+key+')').width(default_width[key]);
					}else{
						$(val).css({width:''});
						$('.table_thead_fixed thead tr:first th:eq('+key+')').width($(val).width());
					}
				});
			}
		)
	}
});

function querySt(ji) {
    hu = window.location.search.substring(1);
    gy = hu.split("&");
    for (i = 0; i < gy.length; i++) {
        ft = gy[i].split("=");
        if (ft[0] == ji) {
            return ft[1];
        }
    }
}