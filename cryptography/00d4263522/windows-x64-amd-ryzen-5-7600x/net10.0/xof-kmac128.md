| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   3.157 μs | 0.0103 μs | 0.0096 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   4.008 μs | 0.0140 μs | 0.0109 μs |   9,969 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   5.156 μs | 0.0101 μs | 0.0085 μs |  13,881 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   4.359 μs | 0.0193 μs | 0.0181 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |   5.485 μs | 0.0154 μs | 0.0137 μs |   9,949 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   6.984 μs | 0.0167 μs | 0.0156 μs |  13,919 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  12.771 μs | 0.0825 μs | 0.0689 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  15.942 μs | 0.0375 μs | 0.0332 μs |  10,004 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  19.943 μs | 0.1002 μs | 0.0937 μs |  13,936 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 159.783 μs | 0.6254 μs | 0.5222 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 196.274 μs | 0.3440 μs | 0.2873 μs |   9,991 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 245.452 μs | 0.8522 μs | 0.7554 μs |  13,949 B |     128 B |