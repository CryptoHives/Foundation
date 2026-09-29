| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   3.702 μs | 0.0205 μs | 0.0181 μs |   5,181 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   4.569 μs | 0.0363 μs | 0.0339 μs |   2,813 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   5.664 μs | 0.0379 μs | 0.0355 μs |   7,098 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   5.265 μs | 0.0437 μs | 0.0409 μs |   5,181 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |   6.487 μs | 0.0275 μs | 0.0257 μs |   2,813 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   8.080 μs | 0.0534 μs | 0.0500 μs |   7,114 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  17.200 μs | 0.1754 μs | 0.1641 μs |   5,181 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  20.956 μs | 0.1442 μs | 0.1349 μs |   2,813 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  26.385 μs | 0.1632 μs | 0.1274 μs |   7,114 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 219.181 μs | 1.2145 μs | 1.1360 μs |   5,179 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 267.832 μs | 2.7396 μs | 2.5627 μs |   2,813 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 338.507 μs | 1.4570 μs | 1.3629 μs |   7,114 B |         - |