| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   2.671 μs | 0.0177 μs | 0.0157 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   3.337 μs | 0.0198 μs | 0.0185 μs |   3,013 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   4.101 μs | 0.0242 μs | 0.0215 μs |   6,827 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   3.847 μs | 0.0314 μs | 0.0278 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |   4.803 μs | 0.0381 μs | 0.0318 μs |   3,011 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   6.078 μs | 0.0413 μs | 0.0386 μs |   7,268 B |    1152 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  12.113 μs | 0.0700 μs | 0.0620 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  14.957 μs | 0.0786 μs | 0.0697 μs |   3,011 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  19.941 μs | 0.2308 μs | 0.2046 μs |   7,268 B |    9216 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 156.775 μs | 1.3213 μs | 1.2359 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 192.433 μs | 1.6630 μs | 1.5556 μs |   3,013 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 261.216 μs | 2.5174 μs | 2.2316 μs |   7,265 B |  149760 B |