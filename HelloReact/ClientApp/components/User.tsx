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
    this.setState({newUserName: d.target.value });
  }

  private addNewUser(): void {
    fetch('api/User/AddNewUser',{
        method: 'POST',
        mode: 'cors',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          UserName: this.state.newUserName,
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
            </tr>
          </thead>
          <tbody>
            {this.state.users.map((u, i) => (
              <tr key={i}>
                <td className="active">{u.name}</td>
                <td className="active">{u.id}</td>
              </tr>
            ))}
          </tbody>
        </table>
        <div className="input-group-lg">
          <input placeholder="New User Name" onChange={this.changeText.bind(this)}/>&nbsp;&nbsp;
          <button className="btn btn-primary btn-sm" onClick={this.addNewUser.bind(this)}>Add</button>
        </div>
      </div>);
  }

}
