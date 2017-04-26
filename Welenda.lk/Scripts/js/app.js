var app = angular.module('welendaApp', ['auth.services']);
var productdId = null;

function notification() {
    $('.notification').slideUp('fast');
}

app.controller('HomeCtrl', function($scope, Auth) {
    $scope.RegTxt = "Register";
    $scope.LoginText = "Login";
    
    if (Auth.isLoggedIn()) {
        var user = Auth.getUser();
        $scope.username = user.name;
        $scope.isLoggedIn = true;
    } else {
        $scope.usable = !$scope.usable;
        $scope.isLoggedIn = false;
    }
    
    $scope.logoutUser = function () {
        if (confirm("Do you want to logout?")) {
            Auth.logout();
            location.reload();
        }
    }
});

app.controller('cartBtnCtrl', function ($scope, Auth) {
    $scope.usable = true;

    if (Auth.isLoggedIn()) {
        var user = Auth.getUser();
        $scope.username = user.name;
        $scope.isLoggedIn = true;
        $scope.usable = true;

        $.ajax({
            type: "POST",
            dataType: "json",
            url: "/Basket/GetCartItemCount",
            data: { userId: user.welendaUserId, name: user.name }
        })
        .success(function (data) {
            if (data != null) {
                $scope.$apply(function () {
                    if (data.basketItemCount == 0) {
                        $scope.cartItemCount = "Cart is Empty";
                    }
                    else {
                        $scope.cartItemCount = data.basketItemCount + " item(s)";
                    }
                });
            }
        })
        .fail(function (xhr) {
            alert(xhr.responseText);
        });
    } else {
        $scope.usable = !$scope.usable;
        $scope.cartItemCount = "Cart is Empty";
        $scope.isLoggedIn = false;
    }

    $scope.GoToShoppingCart = function () {
        var user = Auth.getUser().welendaUserId;
        window.location = "/Basket/Index?id=" + user;
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
        window.location = "/Product/Index?productdId=" + productdId;
    }
});

app.controller('ProdDetailsCtrl', function ($scope, Auth) {
    $scope.addToBasket = function (title, prodId) {
        if (!Auth.isLoggedIn()) {
            ShowLoginAlert();
        }
        else {
            alertify.confirm('Add to Cart', 'Do you want to add ' + title + ' to the cart?',
                function () {
                    if ($scope.itemQuantity != undefined) {
                        $.ajax({
                            type: "POST",
                            dataType: "json",
                            url: "/Basket/AddItemToBasket",
                            data: { productId: prodId, quantity: $scope.itemQuantity, userId: Auth.getUser().welendaUserId, name: Auth.getUser().name }
                        })
                        .success(function (data) {
                            if (data.errorCode == 3) {
                                $scope.$apply(function () {
                                    $scope.notificationtext = "Successfully Added " + title + " to the Cart";
                                });
                                $('.notification').slideDown('fast');
                                window.setTimeout(notification, 3000);
                            }
                            else if (data.errorCode == 5) {
                                alertify.alert('Item Already Exists', 'You have already added this item to the cart. Go to Shopping cart to change the product quantity...', function () { });
                            }
                            else {
                                alert('An error occured. Please try again later.');
                            }
                        })
                        .fail(function (xhr) {
                            alert(xhr.responseText);
                        });
                    }
                    else {
                        alertify.alert('Please select an item quantity..', function () { });
                    }
                },
                function () {
                }
            );
        }
       
    }
});

function ShowLoginAlert(){
    if (!alertify.errorAlert) {
        //define a new errorAlert base on alert
        alertify.dialog('errorAlert', function factory() {
            return {
                build: function () {
                    var errorHeader = '<span class="fa fa-times-circle fa-2x" '
                    + 'style="vertical-align:middle;color:#e10000;">'
                    + '</span> <span style="font-size: 15px;">Please Login/Register</span>';
                    this.setHeader(errorHeader);
                }
            };
        }, true, 'alert');
    }

    alertify
        .errorAlert("Please Login or Register to purchase an Item..! If you are already a user please login. If not get register with us.<br/>" +
            "<div style=\"margin-top: 24px;\">" +
                "<a href=\"/Auth/Login/\" class=\"btn btn-primary\"><i class=\"fa fa-sign-in\"></i>Login</a>" +
                "<a href=\"/Auth/Register/\" style=\"float:right\" class=\"btn btn-default\"><i class=\"fa fa-users\"></i>Register</a>" +
            "</div>")
}

app.controller('shoppingCartCtrl', function ($scope, Auth) {
    $scope.gobackHistory = function () {
        window.history.back();
    }
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
        } else{
            $.ajax({
                type: "POST",
                dataType: "json",
                url: "/Auth/CreateNewUser",
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
               url: "/Auth/LoginUser",
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
                        Auth.setUser(data.userResult[0].uid.trim(), data.userResult[0].name.trim());
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


