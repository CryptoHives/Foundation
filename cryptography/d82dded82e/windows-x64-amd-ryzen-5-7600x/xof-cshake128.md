| Description                              | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · Managed      | 128B         |   2.722 μs | 0.0137 μs | 0.0122 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 128B         |   4.002 μs | 0.0272 μs | 0.0254 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · Managed      | 1KB          |   4.421 μs | 0.0211 μs | 0.0187 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 1KB          |   5.903 μs | 0.0342 μs | 0.0320 μs |    1152 B |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · Managed      | 8KB          |  16.946 μs | 0.0769 μs | 0.0682 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 8KB          |  22.867 μs | 0.3172 μs | 0.2967 μs |    9216 B |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · Managed      | 128KB        | 232.613 μs | 1.3545 μs | 1.2007 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 128KB        | 253.865 μs | 1.3373 μs | 1.2509 μs |  149760 B |