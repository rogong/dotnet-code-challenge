# dotnet-code-challenge

To run this project, clone the repo, the project has two folders, 
client for the frontend(react), while NetTest for the backend(.net core5)
Open the project in vs code, cd "Client" and run npm install or yarn to install the dependencies
cd NetTest and run dotnet build to download the dependencies packages

To start the client project run "yarn start" or "npm start" 

To start  NetTest project, you have to provide Cloudinary Secret keys, the cloudinary provides free storage for our uploaded documents
To get the keys kindly visit https://cloudinary.com/ to signup for free account

After getting your secret keys on Cloudinary, cd into NetTest folder from yout terminal and enter these commmands one by one
dotnet user-secrets set "Cloudinary:CloudName" "your cloudeName goes here"
dotnet user-secrets set "Cloudinary:Apikey" "your Apikey goes here"
dotnet user-secrets set "Cloudinary:ApiSecret" "your ApiSecret goes here"

Don't forget to substitute your keys 


To run NetTest .net core 5 project, simply run "dotnet watch run" 
the swagger doc will popup from the browser, you can see the endpoints





