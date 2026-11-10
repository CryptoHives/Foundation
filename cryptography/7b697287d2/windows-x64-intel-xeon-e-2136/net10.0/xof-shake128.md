| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   5.447 μs | 0.0051 μs | 0.0047 μs |   5,197 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   7.255 μs | 0.0069 μs | 0.0064 μs |   7,082 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   7.600 μs | 0.0100 μs | 0.0089 μs |   3,105 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   7.835 μs | 0.0057 μs | 0.0050 μs |   5,201 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |  10.511 μs | 0.0116 μs | 0.0103 μs |   7,116 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |  11.015 μs | 0.0256 μs | 0.0240 μs |   3,105 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  24.462 μs | 0.0190 μs | 0.0178 μs |   5,201 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  33.314 μs | 0.0317 μs | 0.0281 μs |   7,111 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  34.934 μs | 0.0495 μs | 0.0414 μs |   3,105 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 313.490 μs | 0.1229 μs | 0.1027 μs |   5,199 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 430.366 μs | 0.5604 μs | 0.4680 μs |   7,106 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 448.989 μs | 0.7643 μs | 0.7149 μs |   3,105 B |         - |