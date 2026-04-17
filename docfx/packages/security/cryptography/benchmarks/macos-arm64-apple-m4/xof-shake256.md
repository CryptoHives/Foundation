| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   2.525 μs | 0.0185 μs | 0.0173 μs |         - |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   2.784 μs | 0.0062 μs | 0.0048 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   3.768 μs | 0.0263 μs | 0.0246 μs |    1120 B |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   4.477 μs | 0.0072 μs | 0.0064 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  12.436 μs | 0.0734 μs | 0.0613 μs |    9600 B |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  17.888 μs | 0.2295 μs | 0.2254 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 161.436 μs | 2.6453 μs | 2.5981 μs |  154080 B |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 244.918 μs | 1.7002 μs | 1.5072 μs |         - |