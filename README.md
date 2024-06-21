 Windows Desktop App using Visual Studio with Visual Basic that meets your requirements, follow these steps:


-------Prerequisites-----
Visual Studio Installation: Make sure you have Visual Studio installed. You can download it from the official Microsoft site.


--------Steps to Create the App----------
1. Create a New Visual Basic Windows Forms Application
Open Visual Studio.
Go to File -> New -> Project....
Select Visual Basic from the left menu, and then choose Windows Forms App (.NET Framework) template.
Give your project a name (e.g., "SubmissionApp") and choose a location to save it.
Click Create.
2. Design the User Interface
Design your form using the Form Designer in Visual Studio.
Add necessary controls (textboxes, buttons, etc.) to create a form where users can input data for a submission.
Design additional forms for editing or deleting submissions if you plan to implement those features.
3. Implement Functionality
Implement code to handle creating new submissions.
Implement keyboard shortcuts if needed (e.g., Ctrl + S for saving).
Implement functionality for editing and deleting submissions if desired.


------Compulsory fetaures------
It ise a Windows Desktop App.
It is made with Visual Studio 
It should be able to Create New Submissions.
The code ise put on a public GitHub Repository.
The keyboard shortcuts are working

------Description-------

1)You will create a Form with two buttons - "View Submissions" and "Create New Submission"

![Screenshot (928)](https://github.com/Karansankhe/WinFormsApp-Fontend-/assets/98593148/8b98a9bb-65dd-4c39-952f-eca17c35d94a)

2)When View Submissions is clicked, a new form is opened to View Submissions. The View Submissions Form has two buttons - "Previous" and "Next". By default, the first submitted form entry should be shown. The Next and Previous buttons should let the user go through all form entries one by one.
![Screenshot (931)](https://github.com/Karansankhe/WinFormsApp-Fontend-/assets/98593148/d4df90b5-cfe2-417c-b6b8-fcc867e63a39)

3)When Create New Submission is clicked, another form is opened to Create Submission. It has editable fields for Name, Email, Phone Number, a GitHub repo link. This form also has a button that resumes and pauses a stopwatch. Note that the stopwatch should NOT reset from 0 every time it is paused. It has a Submit button to submit the details to the backend.
![Screenshot (930)](https://github.com/Karansankhe/WinFormsApp-Fontend-/assets/98593148/12b615fc-9e3a-426f-b9ea-222da8fa812b)
