export class RegisterDTO {

  constructor(FirstName: string, LastName: string, Login: string, Password: string, Email: string) {
    this.FirstName = FirstName;
    this.LastName = LastName;
    this.Login = Login;
    this.Password = Password;
    this.Email = Email;
  }

  FirstName: string
  LastName: string
  Login: string
  Password: string
  Email: string
}
