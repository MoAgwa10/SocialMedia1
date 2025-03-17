buf generate -o "src\SocialMediaBackend.Application.Contracts" --template ".\src\SocialMediaBackend.Application.Contracts\buf.gen.yaml" "buf.build/bdaya-dev/social-media-training"
buf generate -o "src\SocialMediaBackend.HttpApi" --template ".\src\SocialMediaBackend.HttpApi\buf.gen.yaml" "buf.build/bdaya-dev/social-media-training"
buf generate -o "src\SocialMediaBackend.HttpApi.Client"--template ".\src\SocialMediaBackend.HttpApi.Client\buf.gen.yaml" "buf.build/bdaya-dev/social-media-training"
