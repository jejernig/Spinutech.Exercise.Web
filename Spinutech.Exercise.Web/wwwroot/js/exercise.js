"use strict";

class Exercise {
    static _controllerPath = '/Exercise';

    static initForm() {
        let validateButton = $('#validateButton');

        validateButton.on('click', function () {
            let validateInput = $('#validateInput').val();
            if (!validateInput || isNaN(validateInput) || parseInt(validateInput) < 0) {
                Exercise.displayErrors(["The Palindrome field is required and must be a non-negative number."]);
                return;
            }
            Exercise.validateInput({ Palindrome: parseInt(validateInput) });
        });
    }

    static async validateInput(palindrome) {
        let url = Exercise._controllerPath + '/ValidateInput';

        try {
            let response = await HttpHandler.post({ url: url, data: palindrome });
            if (response.errorMessages) {
                Exercise.displayErrors(response.errorMessages);
            } else {
                Exercise.displayResult(response);
            }
        } catch (error) {
            if (error.errorMessages) {
                Exercise.displayErrors(error.errorMessages);
            } else {
                console.error(error);
            }
        }
    }

    static displayErrors(messages) {
        let resultDiv = $('#result');
        let errorList = '<ul class="text-danger">';
        messages.forEach(message => {
            errorList += `<li>${message}</li>`;
        });
        errorList += '</ul>';
        resultDiv.html(errorList);
    }

    static displayResult(result) {
        let resultDiv = $('#result');
        if (result.isPalindrome) {
            resultDiv.html('<p class="text-success"><marquee>The number is a palindrome.</marquee></p>');
        } else {
            resultDiv.html('<p class="text-danger"><marquee>The number is not a palindrome.</marquee></p>');
        }
    }
}

$(() => Exercise.initForm());
