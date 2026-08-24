| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Median     | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|-----------:|----------:|
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   2.441 μs | 0.0084 μs | 0.0071 μs |   2.441 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   2.588 μs | 0.0083 μs | 0.0074 μs |   2.587 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 128B         |   9.957 μs | 1.1051 μs | 3.2412 μs |  11.476 μs |         - |
|                                               |              |            |           |           |            |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 1KB          |   3.408 μs | 0.0037 μs | 0.0034 μs |   3.407 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   3.499 μs | 0.0259 μs | 0.0242 μs |   3.486 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   3.679 μs | 0.0098 μs | 0.0092 μs |   3.677 μs |         - |
|                                               |              |            |           |           |            |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 8KB          |  11.837 μs | 0.2367 μs | 0.4672 μs |  12.040 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  12.399 μs | 0.2424 μs | 0.3554 μs |  12.310 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  12.984 μs | 0.2290 μs | 0.2142 μs |  13.111 μs |         - |
|                                               |              |            |           |           |            |           |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 160.948 μs | 1.9002 μs | 1.6845 μs | 160.607 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 170.999 μs | 2.7591 μs | 2.5809 μs | 170.518 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Arm64  | 128KB        | 171.058 μs | 3.3083 μs | 3.9383 μs | 170.475 μs |         - |