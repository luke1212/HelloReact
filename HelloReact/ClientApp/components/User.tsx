import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface UserProp {
}

export class User extends React.Component<RouteComponentProps<{}>, UserProp> {
  constructor(props: any) {
    super(props);
    this.state = {
    };
  }

  componentDidMount() {
    
  }

  public render() {
    return (
      <div className="container">
        <h1>Hi~~ This is your first React WebPage Welcome!</h1>
      </div>
    );
  }

}
