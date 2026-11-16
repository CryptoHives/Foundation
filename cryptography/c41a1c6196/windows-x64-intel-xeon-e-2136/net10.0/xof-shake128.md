| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   5.452 μs | 0.0103 μs | 0.0091 μs |   5,197 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   7.246 μs | 0.0085 μs | 0.0071 μs |   7,095 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   7.611 μs | 0.0099 μs | 0.0083 μs |   3,105 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   7.852 μs | 0.0169 μs | 0.0158 μs |   5,201 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |  10.493 μs | 0.0134 μs | 0.0125 μs |   7,103 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |  10.985 μs | 0.0383 μs | 0.0320 μs |   3,105 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  24.444 μs | 0.0165 μs | 0.0147 μs |   5,201 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  33.370 μs | 0.0879 μs | 0.0822 μs |   7,103 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  35.025 μs | 0.1031 μs | 0.0914 μs |   3,105 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 313.443 μs | 0.2337 μs | 0.2186 μs |   5,199 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 430.164 μs | 0.5770 μs | 0.5115 μs |   7,106 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 447.691 μs | 0.5287 μs | 0.4415 μs |   3,105 B |         - |