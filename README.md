# dotnet-identity-sample

## APIエンドポイント一覧

#### 認証API

| 実装済 | API機能No. | 種別 | APIエンドポイント       | 機能概要                             |
| ------ | ---------- | ---- | ----------------------- | ------------------------------------ |
| ◯      |            | POST | api/account/login       | ログイン機能                         |
| ◯      |            | POST | api/account/register    | ユーザー新規登録                     |
| ◯      |            | GET  | api/account/currentuser | ログイン済みのユーザー情報を返却する |
| ✖️      |            | PUT  | api/account/forget      | ユーザー情報の復活                   |
|        |            |      |                         |                                      |
|        |            |      |                         |                                      |
|        |            |      |                         |                                      |
|        |            |      |                         |                                      |

#### ユーザー管理API

| 実装済 | API機能No. | 種別   | APIエンドポイント  | 機能概要             |
| ------ | ---------- | ------ | ------------------ | -------------------- |
| ◯      |            | GET    | api/account/list   | ユーザーリストを取得 |
| ✖️      |            | DELETE | api/account/delete | ユーザー情報の削除   |
| ✖️      |            | PUT    | api/account/edit   | ユーザー情報の編集   |
| ✖️      |            | POST   | api/account/create | ユーザー情報の作成   |
|        |            |        |                    |                      |

