

// $('#password').on('keyup',function(){
//     if($("#password").val().length < 10){
//         $('#message1').html('Password must be of minium 10 length').css('color', 'red');
//     }
//     else 
//       $('#message1').html('').css();
   
//       var letters = /^[A-Z]$/;
//       var letter1 = /^[a-z]$/;
//       var letter2 = /^[0-9]$/;

//       if($("#password").val().match(letters)){
//           $('#message5').html('').css('');
//       }
//       else 
//         $('#message5').html('Input should contain capital alphabets only').css('color','red');  

//         if($("#password").val().match(letter1)){
//             $('#message5').html('').css('');
//         }
//         else 
//           $('#message5').html('Input should contain small alphabets only').css('color','red');  
       
//           if($("#password").val().match(letter2)){
//             $('#message5').html('').css('');
//         }
//         else 
//           $('#message5').html('Input should contain digits also').css('color','red');  


//   });


$('#password').ready(function(){
    $(".pr-password").passwordRequirements();
  });





// $(".pr-password").passwordRequirements({
//     numCharacters: 8,
//     useLowercase: true,
//     useUppercase: true,
//     useNumbers: true,
//     useSpecial: true
//   });


  // $(".pr-password").passwordRequirements({
  //   style: "dark"
  // });

  // $(".pr-password").passwordRequirements({
  //   fadeTime: 500
  // });
 
 