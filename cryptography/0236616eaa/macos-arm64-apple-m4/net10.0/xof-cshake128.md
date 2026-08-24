| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128B         |   2.452 μs | 0.0087 μs | 0.0077 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 128B         |   2.503 μs | 0.0488 μs | 0.0501 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128B         |   2.559 μs | 0.0494 μs | 0.0709 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   3.806 μs | 0.0361 μs | 0.0302 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 1KB          |  13.637 μs | 0.1184 μs | 0.0989 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 1KB          |  14.318 μs | 0.0303 μs | 0.0268 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 8KB          |  42.147 μs | 0.1305 μs | 0.1157 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 8KB          |  42.700 μs | 0.0537 μs | 0.0419 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 8KB          |  44.576 μs | 0.0283 μs | 0.0237 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 537.395 μs | 4.2535 μs | 3.9788 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128KB        | 552.073 μs | 4.5139 μs | 4.0015 μs |         - |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128KB        | 575.201 μs | 2.5330 μs | 2.3693 μs |         - |