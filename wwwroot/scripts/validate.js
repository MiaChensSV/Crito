
function emailValidator(value) {
    const emailRegEx = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[A-Za-z]{2,}$/;
    if (emailRegEx.test(value)) {
        document.getElementById('contactForm_Email').innerHTML = ""
    } else {
        document.querySelector('contactForm_Email').innerHTML = "Email is invaild"
    }
    return emailRegEx.test("value");
}

function nameValidator(value) {
    const nameRegEx = /^[a-zA-Z]{2,30}$/
    if (nameRegEx.test(value)) {
        document.getElementById('contactForm_Name').innerHTML = ""
    } else {
        document.getElementById('contactForm_Name').innerHTML = "Input is invaild. Name's length should between 2 to 30 characters and can not include special character "
    }
    return nameRegEx.test(value);
}