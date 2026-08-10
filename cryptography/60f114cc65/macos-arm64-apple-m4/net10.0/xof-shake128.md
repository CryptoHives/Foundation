| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 128B         |   2.071 μs | 0.0168 μs | 0.0157 μs |         - |
| AbsorbSqueeze · SHAKE128 · Managed      | 128B         |   2.310 μs | 0.0032 μs | 0.0030 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 1KB          |   3.068 μs | 0.0046 μs | 0.0043 μs |    1152 B |
| AbsorbSqueeze · SHAKE128 · Managed      | 1KB          |   3.869 μs | 0.0076 μs | 0.0071 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 8KB          |  10.046 μs | 0.0154 μs | 0.0144 μs |    9216 B |
| AbsorbSqueeze · SHAKE128 · Managed      | 8KB          |  15.461 μs | 0.0183 μs | 0.0162 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 128KB        | 131.807 μs | 0.1030 μs | 0.0913 μs |  149760 B |
| AbsorbSqueeze · SHAKE128 · Managed      | 128KB        | 215.600 μs | 0.1400 μs | 0.1309 μs |         - |