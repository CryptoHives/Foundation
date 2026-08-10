| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · Managed      | 128B         |   3.394 μs | 0.0199 μs | 0.0186 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native    | 128B         |   4.047 μs | 0.0343 μs | 0.0321 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 128B         |   5.012 μs | 0.0297 μs | 0.0278 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · Managed      | 1KB          |   5.364 μs | 0.0526 μs | 0.0492 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native    | 1KB          |   5.744 μs | 0.0300 μs | 0.0281 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 1KB          |   7.299 μs | 0.0340 μs | 0.0318 μs |    1120 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · OS Native    | 8KB          |  18.539 μs | 0.1094 μs | 0.1023 μs |         - |
| AbsorbSqueeze · SHAKE256 · Managed      | 8KB          |  20.323 μs | 0.1186 μs | 0.1109 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 8KB          |  24.710 μs | 0.1296 μs | 0.1213 μs |    9600 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · OS Native    | 128KB        | 237.210 μs | 1.4442 μs | 1.3509 μs |         - |
| AbsorbSqueeze · SHAKE256 · Managed      | 128KB        | 276.694 μs | 2.3818 μs | 2.2279 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 128KB        | 325.734 μs | 4.1068 μs | 3.8415 μs |  154080 B |