| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · Managed      | 128B         |   2.811 μs | 0.0159 μs | 0.0149 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native    | 128B         |   3.342 μs | 0.0218 μs | 0.0204 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 128B         |   4.131 μs | 0.0256 μs | 0.0240 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · Managed      | 1KB          |   4.571 μs | 0.0282 μs | 0.0263 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native    | 1KB          |   4.801 μs | 0.0299 μs | 0.0280 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 1KB          |   6.098 μs | 0.0553 μs | 0.0490 μs |    1152 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · OS Native    | 8KB          |  15.088 μs | 0.1631 μs | 0.1446 μs |         - |
| AbsorbSqueeze · SHAKE128 · Managed      | 8KB          |  17.424 μs | 0.1068 μs | 0.0999 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 8KB          |  19.935 μs | 0.1608 μs | 0.1504 μs |    9216 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · OS Native    | 128KB        | 193.946 μs | 1.6483 μs | 1.5418 μs |         - |
| AbsorbSqueeze · SHAKE128 · Managed      | 128KB        | 239.547 μs | 1.8561 μs | 1.6454 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 128KB        | 263.310 μs | 2.4667 μs | 2.3074 μs |  149760 B |