| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128B         |   2.607 μs | 0.0144 μs | 0.0135 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128B         |   4.013 μs | 0.0173 μs | 0.0135 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 1KB          |   3.763 μs | 0.0138 μs | 0.0115 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 1KB          |   5.939 μs | 0.0213 μs | 0.0178 μs |    1152 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 8KB          |  11.874 μs | 0.0497 μs | 0.0415 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 8KB          |  19.493 μs | 0.1138 μs | 0.1065 μs |    9216 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128KB        | 152.646 μs | 0.5885 μs | 0.5217 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128KB        | 253.871 μs | 0.5608 μs | 0.4379 μs |  149760 B |