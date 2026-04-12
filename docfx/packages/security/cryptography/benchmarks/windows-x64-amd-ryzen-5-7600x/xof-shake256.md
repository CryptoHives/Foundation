| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · Managed      | 128B         |   3.324 μs | 0.0206 μs | 0.0183 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native    | 128B         |   3.955 μs | 0.0455 μs | 0.0403 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 128B         |   4.913 μs | 0.0243 μs | 0.0216 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · Managed      | 1KB          |   5.239 μs | 0.0360 μs | 0.0337 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native    | 1KB          |   5.640 μs | 0.0947 μs | 0.0791 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 1KB          |   7.158 μs | 0.0251 μs | 0.0223 μs |    1120 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · OS Native    | 8KB          |  18.263 μs | 0.1746 μs | 0.1548 μs |         - |
| AbsorbSqueeze · SHAKE256 · Managed      | 8KB          |  20.121 μs | 0.1469 μs | 0.1302 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 8KB          |  24.182 μs | 0.1448 μs | 0.1355 μs |    9600 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · OS Native    | 128KB        | 232.295 μs | 1.3499 μs | 1.2627 μs |         - |
| AbsorbSqueeze · SHAKE256 · Managed      | 128KB        | 271.443 μs | 2.4825 μs | 2.2007 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 128KB        | 319.262 μs | 2.8065 μs | 2.6252 μs |  154080 B |