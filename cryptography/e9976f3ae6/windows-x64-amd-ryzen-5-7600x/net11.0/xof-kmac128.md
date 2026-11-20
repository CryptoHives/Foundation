| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   3.521 μs | 0.0102 μs | 0.0085 μs |  17,815 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   4.491 μs | 0.0105 μs | 0.0088 μs |  16,517 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   5.743 μs | 0.0100 μs | 0.0089 μs |  24,661 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   4.873 μs | 0.0166 μs | 0.0147 μs |  17,996 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |   6.142 μs | 0.0329 μs | 0.0291 μs |  19,773 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   7.798 μs | 0.0299 μs | 0.0265 μs |  18,158 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  14.325 μs | 0.0540 μs | 0.0479 μs |  11,480 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  17.720 μs | 0.0549 μs | 0.0458 μs |  16,110 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  22.250 μs | 0.0383 μs | 0.0319 μs |  24,671 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 177.800 μs | 0.6017 μs | 0.5334 μs |  17,815 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 219.300 μs | 0.4034 μs | 0.3368 μs |  20,932 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 273.902 μs | 0.7876 μs | 0.6982 μs |  18,146 B |     128 B |