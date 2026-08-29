| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   3.154 μs | 0.0235 μs | 0.0220 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   4.015 μs | 0.0199 μs | 0.0186 μs |   9,971 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   5.138 μs | 0.0202 μs | 0.0168 μs |  13,881 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   4.340 μs | 0.0449 μs | 0.0375 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |   5.464 μs | 0.0298 μs | 0.0232 μs |   9,953 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   6.983 μs | 0.0121 μs | 0.0094 μs |  13,919 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  12.722 μs | 0.0575 μs | 0.0510 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  15.893 μs | 0.1068 μs | 0.0892 μs |   9,374 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  19.872 μs | 0.0945 μs | 0.0884 μs |  13,915 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 160.228 μs | 1.9608 μs | 1.6373 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 195.825 μs | 0.7636 μs | 0.7143 μs |   9,991 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 244.593 μs | 1.1069 μs | 0.9813 μs |  13,949 B |     128 B |