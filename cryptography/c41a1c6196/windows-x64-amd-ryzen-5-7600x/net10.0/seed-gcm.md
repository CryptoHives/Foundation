| Description                             | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 128B         |     1.367 μs | 0.0017 μs | 0.0015 μs |     306 B |         - |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 128B         |     1.817 μs | 0.0029 μs | 0.0027 μs |     306 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 128B         |     1.866 μs | 0.0034 μs | 0.0032 μs |     306 B |     944 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 128B         |     1.330 μs | 0.0012 μs | 0.0012 μs |     383 B |         - |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 128B         |     1.769 μs | 0.0030 μs | 0.0028 μs |     383 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 128B         |     1.770 μs | 0.0045 μs | 0.0042 μs |     386 B |     928 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 1KB          |     9.525 μs | 0.0128 μs | 0.0120 μs |     306 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 1KB          |    10.509 μs | 0.0107 μs | 0.0095 μs |     306 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 1KB          |    12.470 μs | 0.0193 μs | 0.0151 μs |     306 B |         - |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 1KB          |     9.487 μs | 0.0077 μs | 0.0065 μs |     383 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 1KB          |    10.448 μs | 0.0144 μs | 0.0135 μs |     383 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 1KB          |    12.443 μs | 0.0203 μs | 0.0180 μs |     383 B |         - |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 8KB          |    74.722 μs | 0.0466 μs | 0.0389 μs |     306 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 8KB          |    79.469 μs | 0.0351 μs | 0.0274 μs |     306 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 8KB          |    97.713 μs | 0.1572 μs | 0.1471 μs |     306 B |         - |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 8KB          |    74.694 μs | 0.0638 μs | 0.0597 μs |     383 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 8KB          |    79.742 μs | 0.0628 μs | 0.0587 μs |     383 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 8KB          |    97.685 μs | 0.1004 μs | 0.0890 μs |     383 B |         - |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 128KB        | 1,192.983 μs | 1.0788 μs | 1.0091 μs |     306 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 128KB        | 1,263.482 μs | 0.6198 μs | 0.5494 μs |     306 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 128KB        | 1,561.228 μs | 2.7180 μs | 2.4094 μs |     306 B |         - |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 128KB        | 1,192.958 μs | 1.0351 μs | 0.9683 μs |     383 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 128KB        | 1,269.283 μs | 0.8422 μs | 0.7466 μs |     383 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 128KB        | 1,559.608 μs | 2.2132 μs | 1.9620 μs |     383 B |         - |