| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · Managed      | 128B         |   2.760 μs | 0.0185 μs | 0.0173 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native    | 128B         |   3.276 μs | 0.0242 μs | 0.0226 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 128B         |   4.050 μs | 0.0259 μs | 0.0242 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · Managed      | 1KB          |   4.458 μs | 0.0244 μs | 0.0204 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native    | 1KB          |   4.722 μs | 0.0347 μs | 0.0324 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 1KB          |   5.988 μs | 0.0216 μs | 0.0169 μs |    1152 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · OS Native    | 8KB          |  14.804 μs | 0.0906 μs | 0.0803 μs |         - |
| AbsorbSqueeze · SHAKE128 · Managed      | 8KB          |  17.109 μs | 0.1303 μs | 0.1088 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 8KB          |  19.552 μs | 0.1473 μs | 0.1378 μs |    9216 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · OS Native    | 128KB        | 190.730 μs | 1.3111 μs | 1.2264 μs |         - |
| AbsorbSqueeze · SHAKE128 · Managed      | 128KB        | 235.864 μs | 1.4776 μs | 1.2339 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 128KB        | 257.714 μs | 1.4397 μs | 1.3467 μs |  149760 B |