# dotnet-code-challenge

<ul>

<li>To run this project, clone the repo, the project has two folders,  </li>
<li>client for the frontend(react), while NetTest for the backend(.net core5) </li>
<li>Open the project in vs code, cd "Client" and run npm install or yarn to install the dependencies </li>
<li>cd NetTest and run dotnet build to download the dependencies packages </li>

<li>To start the client project run "yarn start" or "npm start"  </li>

<li>To start  NetTest project, you have to provide Cloudinary Secret keys, the cloudinary provides free storage for our uploaded documents </li>
<li>To get the keys kindly visit https://cloudinary.com/ to signup for free account </li>

<li>After getting your secret keys on Cloudinary, cd into NetTest folder from yout terminal and enter these commmands one by one </li>
<li>dotnet user-secrets set "Cloudinary:CloudName" "your cloudeName goes here" </li>
<li>dotnet user-secrets set "Cloudinary:Apikey" "your Apikey goes here" </li>
<li>dotnet user-secrets set "Cloudinary:ApiSecret" "your ApiSecret goes here" </li>

<li>Don't forget to substitute your keys </li>

<li>To migrate 
<li>Run "dotnet ef migrations add "Initial Create" -o Data/Migrations </li>

<li>The next thing is to start the project, that will automatically seed the dummmy data </li>

<li>Run "dotnet watch run" </li>
<li>the swagger doc will popup from the browser, you can see the endpoints </li>





