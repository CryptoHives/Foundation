| Description                              | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 128B         |   2.065 μs | 0.0074 μs | 0.0062 μs |         - |
| AbsorbSqueeze · cSHAKE128 · Managed      | 128B         |   2.304 μs | 0.0021 μs | 0.0018 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 1KB          |   3.076 μs | 0.0067 μs | 0.0063 μs |    1152 B |
| AbsorbSqueeze · cSHAKE128 · Managed      | 1KB          |   3.860 μs | 0.0104 μs | 0.0092 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 8KB          |  10.597 μs | 0.0287 μs | 0.0268 μs |    9216 B |
| AbsorbSqueeze · cSHAKE128 · Managed      | 8KB          |  15.470 μs | 0.0082 μs | 0.0072 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 128KB        | 132.217 μs | 0.2522 μs | 0.2359 μs |  149760 B |
| AbsorbSqueeze · cSHAKE128 · Managed      | 128KB        | 215.826 μs | 0.2062 μs | 0.1929 μs |         - |