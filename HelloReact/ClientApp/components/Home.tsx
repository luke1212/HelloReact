import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { UserModel } from 'ClientApp/genModels/UserModel';
import { ImageListModel } from 'ClientApp/genModels/ImageListModel';

interface HomeState {
  users: UserModel[];
  newUserName: string;
  imageList: ImageListModel;
}

export class Home extends React.Component<RouteComponentProps<{}>, HomeState> {
  constructor(props: any) {
    super(props);
    this.state = {
      users: [],
      newUserName: "",
      imageList: { fileNames: [] }
    };
  }

  componentDidMount() {
    fetch('api/User/GetImages')
      .then(response => response.json() as Promise<ImageListModel>)
      .then(data => {
        this.setState({ imageList: data })
      });
  }

  public render() {
    return (
      <div>
        <h1 className="text-center">Welcome to Betty and Luke's Home</h1>
        <img src={this.state.imageList.fileNames[this.state.imageList.fileNames.length-1]} />
      </div>
    )
  }
}
