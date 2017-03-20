var app = angular.module('welendaApp', ['auth.services']);
var productdId = null;

app.controller('HomeCtrl', function($scope, Auth) {
    $scope.RegTxt = "Register";
    $scope.LoginText = "Login";
    
    if (Auth.isLoggedIn()){
      $scope.username = Auth.getUser().name;
      $scope.isLoggedIn = true;   
    }else{
      $scope.isLoggedIn = false;
    }
    
    $scope.logoutUser = function() {
        if (confirm("Do you want to logout?")) {
            Auth.logout();
            location.reload();
        }
    }
});

app.controller('homeProdCtrl', function ($scope) {
    $.ajax({
         type: "POST",
         dataType: "json",
         url: "Home/GetHotProducts",
     })
    .success(function (data) {
        if (data != null) {
            $scope.$apply(function () {
                $scope.hotProducts = data.hotProducts;
            });           
        }

        $.ajax({
            type: "POST",
            dataType: "json",
            url: "Home/GetElectronicsProducts",
        })
        .success(function (data) {
            if (data != null) {
                $scope.$apply(function () {
                    $scope.ElectornicsProducts = data.ElectornicsProducts;
                });
            }

            $.ajax({
                type: "POST",
                dataType: "json",
                url: "Home/GetToyProducts",
            })
            .success(function (data) {
                if (data != null) {
                    $scope.$apply(function () {
                        $scope.ToyProducts = data.ToyProducts;
                    });
                }
            })
            .fail(function (xhr) {
                alert(xhr.responseText);
            });
        })
        .fail(function (xhr) {
            alert(xhr.responseText);
        });
    })
    .fail(function (xhr) {
        alert(xhr.responseText);
    });

    $scope.getProductDetails = function (productdId, details) {

        if (window.localStorage['prodcuctDetails']) {
            window.localStorage.removeItem("prodcuctDetails");
        }
        var _prodcuctDetails = { "prodcuctId": productdId, "details": details };
        window.localStorage['prodcuctDetails'] = JSON.stringify(_prodcuctDetails);

        window.location = "/Product/Index?productdId=" + productdId;
    }
});

app.controller('ProdDetailsCtrl', function ($scope, Auth) {

});

app.controller('AuthCtrl', function($scope, Auth) {
    $scope.submitFormRegister = function(user) {
        if (user == undefined || user.email == undefined || user.name == undefined ||
            user.password == undefined || user.rePassword == undefined ){
            alert('Please fill out all the fields.');
        }
        else if (user.password.length < 6){
            alert('Password length should atlease 6 characters.');
        }
        else if (user.password != user.rePassword){
            alert('Passwords do not match.');
        }
        else if (!checkEmail(user.email)) {
            alert('Invalid Email Format.');
        }else{
            $.ajax({
                type: "POST",
                dataType: "json",
                url: "CreateNewUser",
                data: { email: user.email , password: user.password, name: user.name }
            })
            .success(function (data) {
                if (data == 0) {
                    alert('An error occured. Please try again.');
                }
                else if (data == 1) {
                    alert('Already exists an account with the given email address.');
                }
                else if (data == 3) {
                    alert('You have successfully registered. Now login using email and password');
                }
            })
            .fail(function (xhr) {
                alert(xhr.responseText);
            });
        }
    };

    function checkEmail(x) {
        var atpos = x.indexOf("@");
        var dotpos = x.lastIndexOf(".");
        if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {            
            return false;
        }
        
        return true;
    }
    
    $scope.submitFormLogin = function(user) {
       if (user.loginEmail == undefined || user.loginPassword == undefined ){
          alert('Please enter email/password');
       }
       else{
           $.ajax({
               type: "POST",
               dataType: "json",
               url: "LoginUser",
               data: { email: user.loginEmail, password: user.loginPassword }
           })
            .success(function (data) {
                if (data != null){
                    if (data.errorCode == 0) {
                        alert('An error occured. Please try again.');
                    }
                    else if (data.errorCode == 2) {
                        alert('No user corresponding to the given email and password.');
                    }
                    else if (data.errorCode == 3) {
                        Auth.setUser(data.result[4], data.result[3]);
                        window.location.href = '/';
                    }
                }                
            })
            .fail(function (xhr) {
                alert(xhr.responseText);
            });
       }
   };
});

angular.module('auth.services', [])
.factory('Auth', function () {
   return {
      setUser: function (userId, name) {
         var _user = { "welendaUserId" : userId, "name": name };
         window.localStorage['welendaSession'] = JSON.stringify(_user);
      },
      isLoggedIn: function () {
          return window.localStorage['welendaSession'] ? true : false;
      },
      getUser: function () {
         return JSON.parse(window.localStorage['welendaSession']);
      },
      logout: function () {
         window.localStorage.removeItem("welendaSession");
         _user = null;
      }
   }
});


