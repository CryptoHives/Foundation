| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   5.444 μs | 0.0066 μs | 0.0055 μs |  15,905 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   7.255 μs | 0.0036 μs | 0.0032 μs |  16,072 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   7.655 μs | 0.0531 μs | 0.0497 μs |  10,706 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   7.837 μs | 0.0103 μs | 0.0092 μs |  16,086 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |  10.535 μs | 0.0218 μs | 0.0204 μs |  16,094 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |  10.997 μs | 0.0420 μs | 0.0351 μs |  10,706 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  24.437 μs | 0.0148 μs | 0.0138 μs |  16,095 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  33.369 μs | 0.0427 μs | 0.0399 μs |   9,759 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  35.082 μs | 0.1265 μs | 0.1184 μs |  12,155 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 313.205 μs | 0.1319 μs | 0.1169 μs |   9,561 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 430.208 μs | 0.1832 μs | 0.1714 μs |  16,094 B |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 449.147 μs | 0.5530 μs | 0.4903 μs |   5,820 B |         - |