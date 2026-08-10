| Description                              | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 128B         |   2.501 μs | 0.0068 μs | 0.0053 μs |         - |
| AbsorbSqueeze · cSHAKE256 · Managed      | 128B         |   2.755 μs | 0.0055 μs | 0.0051 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 1KB          |   3.655 μs | 0.0046 μs | 0.0041 μs |    1120 B |
| AbsorbSqueeze · cSHAKE256 · Managed      | 1KB          |   4.461 μs | 0.0066 μs | 0.0058 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 8KB          |  12.304 μs | 0.0191 μs | 0.0179 μs |    9600 B |
| AbsorbSqueeze · cSHAKE256 · Managed      | 8KB          |  17.681 μs | 0.0145 μs | 0.0121 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 128KB        | 159.465 μs | 0.2552 μs | 0.2387 μs |  154080 B |
| AbsorbSqueeze · cSHAKE256 · Managed      | 128KB        | 242.919 μs | 0.1775 μs | 0.1573 μs |         - |