
$('#password').on('keyup',function(){
    var letters = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    
     if($("#password").val().length==0)
     {
      $('#message5').text('');
     }
     else if($('#password').val().match(letters))
     {
        $('#message5').text('');
     }
     else{
        $('#message5').html('Incorrect input').css('color','red');
     }

  });

  



 


