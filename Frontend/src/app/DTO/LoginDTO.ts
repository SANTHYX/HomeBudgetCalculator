export class LoginDTO {
  constructor(login: string, password: string) {
    this.Login = login
    this.Password = password
  }

  Login: string
  Password: string
}
