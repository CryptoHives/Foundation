| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128B         |   2.277 μs | 0.0018 μs | 0.0017 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   2.441 μs | 0.0019 μs | 0.0017 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   2.608 μs | 0.0049 μs | 0.0041 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 1KB          |   3.135 μs | 0.0011 μs | 0.0010 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   3.367 μs | 0.0043 μs | 0.0041 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   3.624 μs | 0.0076 μs | 0.0071 μs |    1280 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 8KB          |   9.098 μs | 0.0046 μs | 0.0041 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |   9.769 μs | 0.0246 μs | 0.0218 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  11.263 μs | 0.0151 μs | 0.0141 μs |    9344 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128KB        | 113.112 μs | 0.0319 μs | 0.0299 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 121.260 μs | 0.1295 μs | 0.1082 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 132.827 μs | 0.1609 μs | 0.1505 μs |  149888 B |