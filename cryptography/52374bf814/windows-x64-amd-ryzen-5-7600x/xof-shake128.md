| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · Managed      | 128B         |   2.720 μs | 0.0137 μs | 0.0128 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native    | 128B         |   3.243 μs | 0.0200 μs | 0.0187 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 128B         |   3.998 μs | 0.0187 μs | 0.0156 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · Managed      | 1KB          |   4.426 μs | 0.0280 μs | 0.0248 μs |         - |
| AbsorbSqueeze · SHAKE128 · OS Native    | 1KB          |   4.677 μs | 0.0385 μs | 0.0360 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 1KB          |   5.918 μs | 0.0386 μs | 0.0361 μs |    1152 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · OS Native    | 8KB          |  14.587 μs | 0.0576 μs | 0.0511 μs |         - |
| AbsorbSqueeze · SHAKE128 · Managed      | 8KB          |  16.924 μs | 0.1154 μs | 0.1080 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 8KB          |  19.362 μs | 0.1191 μs | 0.1114 μs |    9216 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · OS Native    | 128KB        | 187.459 μs | 0.8724 μs | 0.7734 μs |         - |
| AbsorbSqueeze · SHAKE128 · Managed      | 128KB        | 232.700 μs | 1.6526 μs | 1.5458 μs |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 128KB        | 254.371 μs | 1.0497 μs | 0.9305 μs |  149760 B |