import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import { UserModel } from '../genModels/UserModel';
import { Row, Table,} from 'react-bootstrap';

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
      </div>
    );
  }

}
