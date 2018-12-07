import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import { UserModel } from '../genModels/UserModel';
import { Row, Table, } from 'react-bootstrap';

interface UserState {
  users: UserModel[];
  newUserName: string;
}

interface UserProp {
}

export class User extends React.Component<RouteComponentProps<{}>, UserState> {
  constructor(props: any) {
    super(props);
    this.state = {
      users: [],
      newUserName: "",
    };
  }

  componentDidMount() {
    fetch('api/User/GetUser')
      .then(response => response.json() as Promise<UserModel[]>)
      .then(data => {
        this.setState({ users: data });
      });
  }

  private changeText(d: any): void {
    this.setState({ newUserName: d.target.value });
  }

  private addNewUser(event: Event): void {
    event.preventDefault();
    this.setState({ newUserName: "" });
    fetch('api/User/AddNewUser', {
      method: 'POST',
      mode: 'cors',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        UserName: this.state.newUserName,
      })
    })
      .then(response => response.json() as Promise<UserModel[]>)
      .then(data => {
        this.setState({ users: data });
      });
  }

  private uploadInput:any;

  private uploadFile(e: any) {
    e.preventDefault();

    var data = new FormData();
    data.append('file', this.uploadInput.files[0]);

    var headers = new Headers();

    fetch('api/User/UploadFile',
      {
        method: 'POST',
        mode: 'cors',
        headers: headers,
        body: data
      });
  }

  private deleteUser(e: any): void {
    this.setState({ users: this.state.users.filter((row) => row.name !== e.target.value) });
    fetch('',
      {
        method: 'POST',
        mode: 'cors',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          UserName: e.target.value,
        })
      });
  }

  public render() {
    return (
      <div className="container">
        <h1>User Table</h1>
        <table className="table table-hover table-condensed">
          <thead>
            <tr className="success">
              <th>User Name</th>
              <th>UserID</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {this.state.users.map((u, i) => (
              <tr key={i}>
                <td className="active">{u.name}</td>
                <td className="active">{u.id}</td>
                <td className="active">
                  <button
                    className="btn glyphicon glyphicon-trash"
                    onClick={this.deleteUser.bind(this)}
                    value={u.name}>
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        <form onSubmit={this.addNewUser.bind(this)}>
          <div className="input-group-lg">
            <input
              placeholder="New User Name"
              onChange={this.changeText.bind(this)}
              value={this.state.newUserName} />&nbsp;&nbsp;
          <button className="btn btn-primary btn-sm">Add</button>
          </div>
        </form>

        <form onSubmit={this.uploadFile.bind(this)} >
          <input type="file" ref={(ref) => { this.uploadInput = ref; }} name="file" />
          <input type="submit" />
        </form>

      </div>);
  }

}
