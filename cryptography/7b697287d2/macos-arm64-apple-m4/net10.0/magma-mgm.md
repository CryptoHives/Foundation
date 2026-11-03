| Description                                | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Magma-MGM (CryptoHives-ArmPmull) | 128B         |     2.819 μs |  0.0102 μs |  0.0095 μs |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar)   | 128B         |     3.103 μs |  0.0139 μs |  0.0130 μs |         - |
|                                            |              |              |            |            |           |
| Encrypt · Magma-MGM (CryptoHives-ArmPmull) | 128B         |     2.804 μs |  0.0102 μs |  0.0095 μs |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar)   | 128B         |     3.087 μs |  0.0113 μs |  0.0105 μs |         - |
|                                            |              |              |            |            |           |
| Decrypt · Magma-MGM (CryptoHives-ArmPmull) | 1KB          |    19.013 μs |  0.0566 μs |  0.0530 μs |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar)   | 1KB          |    20.999 μs |  0.0840 μs |  0.0786 μs |         - |
|                                            |              |              |            |            |           |
| Encrypt · Magma-MGM (CryptoHives-ArmPmull) | 1KB          |    19.021 μs |  0.0952 μs |  0.0890 μs |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar)   | 1KB          |    20.997 μs |  0.0620 μs |  0.0580 μs |         - |
|                                            |              |              |            |            |           |
| Decrypt · Magma-MGM (CryptoHives-ArmPmull) | 8KB          |   148.442 μs |  0.5984 μs |  0.5598 μs |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar)   | 8KB          |   164.298 μs |  0.6606 μs |  0.6179 μs |         - |
|                                            |              |              |            |            |           |
| Encrypt · Magma-MGM (CryptoHives-ArmPmull) | 8KB          |   148.707 μs |  0.8079 μs |  0.7557 μs |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar)   | 8KB          |   164.264 μs |  0.6612 μs |  0.6185 μs |         - |
|                                            |              |              |            |            |           |
| Decrypt · Magma-MGM (CryptoHives-ArmPmull) | 128KB        | 2,369.152 μs | 11.0139 μs | 10.3024 μs |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar)   | 128KB        | 2,619.615 μs | 15.2178 μs | 14.2347 μs |         - |
|                                            |              |              |            |            |           |
| Encrypt · Magma-MGM (CryptoHives-ArmPmull) | 128KB        | 2,372.871 μs | 12.0856 μs | 11.3049 μs |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar)   | 128KB        | 2,623.399 μs | 14.6269 μs | 13.6820 μs |         - |