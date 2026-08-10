| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   3.134 μs | 0.0046 μs | 0.0041 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   3.994 μs | 0.0117 μs | 0.0109 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   5.154 μs | 0.0079 μs | 0.0066 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   4.311 μs | 0.0095 μs | 0.0080 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |   5.479 μs | 0.0089 μs | 0.0074 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   7.151 μs | 0.0103 μs | 0.0086 μs |    1280 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  12.699 μs | 0.0147 μs | 0.0122 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  15.818 μs | 0.0247 μs | 0.0206 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  21.156 μs | 0.0429 μs | 0.0358 μs |    9344 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 157.798 μs | 0.2158 μs | 0.1913 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 195.139 μs | 0.2649 μs | 0.2348 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 266.564 μs | 0.8967 μs | 0.8388 μs |  149888 B |