import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { UserModel } from 'ClientApp/genModels/UserModel';
import { ImageListModel } from 'ClientApp/genModels/ImageListModel';

interface HomeState {
  users: UserModel[];
  newUserName: string;
  imageList: ImageListModel;
}

export class Home extends React.Component<RouteComponentProps<{}>, {}> {
  constructor(props: any) {
    super(props);
    this.state = {
      users: [],
      newUserName: "",
      imageList: { fileNames: [] }
    };
  }

  public render() {
    return (
      <div>
        <h1>Welcome</h1>
      </div>
      )
  }
}
