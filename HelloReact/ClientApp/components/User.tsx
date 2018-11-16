import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import { UserModel } from '../genModels/UserModel';

interface UserState {
  users: UserModel[];
}

interface UserProp {
}

export class User extends React.Component<RouteComponentProps<{}>, UserState> {
  constructor(props: any) {
    super(props);
    this.state = {
      users: [],
    };
  }

  componentDidMount() {
    fetch('api/User/GetUser')
      .then(response => response.json() as Promise<UserModel[]>)
      .then(data => {
        this.setState({ users: data });
      });
  }

  public render() {
    return (
      <div className="container">
        <h1>Hi~~ This is your first React WebPage Welcome!</h1>
        <table>
          <tbody>
            {this.state.users.map((u, i) => (
              <td key={i}>{u.name}</td>
            ))}
          </tbody>
        </table>
      </div>
    );
  }

}
