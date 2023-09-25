



$('#FirstName').on('keyup',function(){
    var letters = /^[A-Za-z]([A-Za-z .])*$/;
    
     if($("#FirstName").val().length==0)
     {
      $('#message2').text('');
     }

    else if($("#FirstName").val().match(letters)){
        $('#message2').text('');
    }
    else 
      $('#message2').html('Input should be alphabets only').css('color','red');
  });

  $('#LastName').on('keyup',function(){
    var letters = /^[A-Za-z]([A-Za-z .])*$/;

    if($("#LastName").val().length==0)
    {
     $('#message3').text('');
    }
    else if($("#LastName").val().match(letters)){
        $('#message3').text('');
    }
    else 
      $('#message3').html('Input should be alphabets only').css('color','red');
  });

  $('#UserName').on('keyup',function(){
     var letters = /^[A-Za-z][A-Za-z0-9]*$/;
     if($("#UserName").val().length==0)
     {
      $('#message6').text('');
     }
     else if($("#UserName").val().match(letters)){
         $('#message6').text('');
     }
     else 
      $('#message6').html('Input should contains alphanumeric').css('color','red');

    var username = $("#UserName").val();
    $.ajax({
        url: '/Signup/checkUserName',
        type: 'GET',
        data: { username: username },
        success: function (response) {
            console.log('response');
            if (response === "true") {
                $('#message4').text('');
                console.log('true');
            } else {
                $('#message4').html('Username is already taken').css('color','red');
                console.log('false');
            }
        },
    });

  }


    )  ;

     
 
  
