# summary_extractor
## 概要
- Todoや質問事項など、日々の作業で出てきた内容の整理ツール

## version
- 0.1

## 開発環境
- C#

## 使い方


## 更新履歴
- 0.1 : 最低限機能構築

## 追加予定機能
- 各ファイルを読み込んで表示機能
    - Todoファイルを読み込んでリストとかで表示する
	- ひとまずメモ帳で読み出すようにした。
    - できたらチェックして終わりにするとかしたい
        - 完了/未完了機能
    ここまでできたらそれなりな気がする。
- 読み取りファイル指定機能追加

# 以下メモ（最終的には削除予定）
# 2023/1/3 ~ 1/5
- [x]ファイル作成ボタン
    - 日々書いていくファイル
- 抽出
    - [x]step1
        - 規定のファイルからデータを抽出し追記
            - 規定のデータ形式を抜き出す
                - [x]ルールを作らないといけない。
                    - 仮ぎめ完了
            - [x]その内容を別のファイルに追記していく
	- display機能追加
    - step2
        - Todo
        - 質問事項
        - その他
        - 終わったやつを移動させる
            - 読み込み機能
            - 表にしてチェックして移動できるようにしたいなぁ。。。

# 2022/12/25
- ガワ
- ボタン2つ作る
    - 一個はmdファイル作成
        - テキストの中のファイル名を読み込んで？
            - いや、ディレクトリを選んでそこにテキストの名前のファイルを作成だよね
    - もう一つは抽出
        - 規定のファイルに追記していく
            - あるファイルからよみとって、指定のファイルに追記って感じ。
                - 抽出モジュールが必要。。。
    
# 2022/12/18
# 〇〇について
### 概要
- ToDo
    - daily
    - 期限あり

- 質問事項
    - リスト化
    - 理解できたら、知ったこと/理解したことへ以降
    - 知ったこと/理解したこと
        - 一覧表に持っていく

- その他

- viewer
- チェック機能
- ベースはテキスト
    - そこから抽出

- マークダウンで表に

### 動作概要
- ボタン押したらその日のmdファイルができる
- 日々の出来事を記載
    - 質問事項とかは特定のなにかをやって記載しておく
- 最後にボタンを押して抽出してリスト化
- ボタンは何個か作っておく。

- pythonで作るか、C#で作るか・・・
- 細かい機能は随時追加していきたいなのできちんと作っていきたいなぁ。
    - C#で行く
- step1を一週間で立ち上げられたら・・・どこまでやるか・・・できる時期は考えずに、じっくりと作るか、、
    - ガワ、ボタン作成
        - 作成フォルダ、日付のボタン作成
            - これはまだなくてもいいか。
    - 該当箇所を抽出し、別のファイルへ追記
        - まずはここかな。
            - 仕様を決めて抜き出すように。。。C#？
            - 最終的にはボタンで。
- 仕様をもう少し固めたほうが良い気もする。

- ToDo
    - ### ToDo
- 質問事項
    - ### 質問事項
- 知ったこと/理解できたこと　- 日付を入れておいて元ファイルを読み出せるようにしておく
    - ### 知ったこと

っていう文字でいい？
はじめとあとはどうやる？
- その他メモ

### 作業ステップ
- Step1
    - 抜き出して、追記する
- Step2
    - 終わったやつを移動させる
- Step3
    - GUIへ

