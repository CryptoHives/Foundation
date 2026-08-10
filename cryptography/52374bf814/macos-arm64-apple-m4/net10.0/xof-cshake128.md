| Description                              | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 128B         |   2.059 μs | 0.0013 μs | 0.0010 μs |         - |
| AbsorbSqueeze · cSHAKE128 · Managed      | 128B         |   2.306 μs | 0.0032 μs | 0.0028 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 1KB          |   3.143 μs | 0.0067 μs | 0.0062 μs |    1152 B |
| AbsorbSqueeze · cSHAKE128 · Managed      | 1KB          |   3.862 μs | 0.0054 μs | 0.0048 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 8KB          |  10.040 μs | 0.0120 μs | 0.0100 μs |    9216 B |
| AbsorbSqueeze · cSHAKE128 · Managed      | 8KB          |  15.470 μs | 0.0230 μs | 0.0204 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 128KB        | 131.999 μs | 0.1655 μs | 0.1548 μs |  149760 B |
| AbsorbSqueeze · cSHAKE128 · Managed      | 128KB        | 215.594 μs | 0.1360 μs | 0.1206 μs |         - |