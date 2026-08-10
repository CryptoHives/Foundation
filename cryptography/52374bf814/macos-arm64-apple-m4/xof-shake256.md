| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 128B         |   2.483 μs | 0.0054 μs | 0.0043 μs |         - |
| AbsorbSqueeze · SHAKE256 · Managed      | 128B         |   2.753 μs | 0.0046 μs | 0.0043 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 1KB          |   3.704 μs | 0.0064 μs | 0.0057 μs |    1120 B |
| AbsorbSqueeze · SHAKE256 · Managed      | 1KB          |   4.454 μs | 0.0086 μs | 0.0081 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 8KB          |  12.184 μs | 0.0211 μs | 0.0197 μs |    9600 B |
| AbsorbSqueeze · SHAKE256 · Managed      | 8KB          |  17.629 μs | 0.0199 μs | 0.0186 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 128KB        | 158.035 μs | 0.3933 μs | 0.3679 μs |  154080 B |
| AbsorbSqueeze · SHAKE256 · Managed      | 128KB        | 242.420 μs | 0.2813 μs | 0.2631 μs |         - |