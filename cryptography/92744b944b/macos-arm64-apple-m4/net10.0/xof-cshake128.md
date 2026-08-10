| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Median     | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|-----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128B         |   2.082 μs | 0.0181 μs | 0.0151 μs |   2.082 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128B         |   2.358 μs | 0.0459 μs | 0.0596 μs |   2.324 μs |         - |
|                                                |              |            |           |           |            |           |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 1KB          |   3.264 μs | 0.0083 μs | 0.0069 μs |   3.265 μs |    1152 B |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 1KB          |   3.876 μs | 0.0042 μs | 0.0039 μs |   3.876 μs |         - |
|                                                |              |            |           |           |            |           |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 8KB          |  10.073 μs | 0.0170 μs | 0.0151 μs |  10.068 μs |    9216 B |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 8KB          |  15.632 μs | 0.1368 μs | 0.1213 μs |  15.635 μs |         - |
|                                                |              |            |           |           |            |           |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128KB        | 133.216 μs | 1.3104 μs | 1.0943 μs | 132.869 μs |  149760 B |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128KB        | 216.171 μs | 0.2724 μs | 0.2127 μs | 216.183 μs |         - |