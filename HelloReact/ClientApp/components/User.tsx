import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface SummaryProp {
}

export class Summary extends React.Component<RouteComponentProps<{}>, SummaryProp> {
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
        <h1>Hi!!! This is your first React WebPage!! Welcome!!!</h1>
      </div>
    );
  }

}
