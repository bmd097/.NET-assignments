{
    let email = document.getElementById("email");
    let password = document.getElementById("password");
    let btn = document.getElementById("logInBtn");
    
    btn.innerText = "Submit or Cookie LogIn";
    btn.addEventListener("click", () => {
            fetch("/api/Authentication", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    email: email.value,
                    password: password.value
                })
            }).then(response => response.json())
                .then(data => {
                    if (data.success === true) {
                        alert('Success!');
                        console.log(data);
                    } else {
                        alert("Failed!");
                    }
                })
                .catch(alert);
        });
    
}