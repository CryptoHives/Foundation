# KangarooTwelve (KT) Test Vectors

Source: RFC 9861

## KT128

### Empty Message, Empty Customization
- **Output (32 bytes):**   `1A C2 D4 50 FC 3B 42 05 D1 9D A7 BF CA 1B 37 51 3C 08 03 57 7A C7 16 7F 06 FE 2C E1 F0 EF 39 E5`
- **Output (64 bytes):**   `1A C2 D4 50 FC 3B 42 05 D1 9D A7 BF CA 1B 37 51 3C 08 03 57 7A C7 16 7F 06 FE 2C E1 F0 EF 39 E5 42 69 C0 56 B8 C8 2E 48 27 60 38 B6 D2 92 96 6C C0 7A 3D 46 45 27 2E 31 FF 38 50 81 39 EB 0A 71`

### Pattern Message (ptn(n)), Empty Customization

**Pattern:** `00 01 02 ... F9 FA` repeated.

| Message Length | Output (32 bytes) |
|----------------|-------------------|
| 1 byte       | `2B DA 92 45 0E 8B 14 7F 8A 7C B6 29 E7 84 A0 58 EF CA 7C F7 D8 21 8E 02 D3 45 DF AA 65 24 4A 1F` |
| 17 bytes       | `6B F7 5F A2 23 91 98 DB 47 72 E3 64 78 F8 E1 9B 0F 37 12 05 F6 A9 A9 3A 27 3F 51 DF 37 12 28 88` |
| 17^2 bytes     | `0C 31 5E BC DE DB F6 14 26 DE 7D CF 8F B7 25 D1 E7 46 75 D7 F5 32 7A 50 67 F3 67 B1 08 EC B6 7C` |
| 17^3 bytes     | `CB 55 2E 2E C7 7D 99 10 70 1D 57 8B 45 7D DF 77 2C 12 E3 22 E4 EE 7F E4 17 F9 2C 75 8F 0D 59 D0` |
| 17^4 bytes     | `87 01 04 5E 22 20 53 45 FF 4D DA 05 55 5C BB 5C 3A F1 A7 71 C2 B8 9B AE F3 7D B4 3D 99 98 B9 FE` |
| 17^5 bytes     | `84 4D 61 09 33 B1 B9 96 3C BD EB 5A E3 B6 B0 5C C7 CB D6 7C EE DF 88 3E B6 78 A0 A8 E0 37 16 82` |
| 17^6 bytes     | `3C 39 07 82 A8 A4 E8 9F A6 36 7F 72 FE AA F1 32 55 C8 D9 58 78 48 1D 3C D8 CE 85 F5 8E 88 0A F8` |

### Messages with Customization

| Message | Customization | Output (32 bytes) |
|---------|---------------|-------------------|
| Empty   | ptn(1)        | `FA B6 58 DB 63 E9 4A 24 61 88 BF 7A F6 9A 13 30 45 F4 6E E9 84 C5 6E 3C 33 28 CA AF 1A A1 A5 83` |
| `FF`    | ptn(41)       | `D8 48 C5 06 8C ED 73 6F 44 62 15 9B 98 67 FD 4C 20 B8 08 AC C3 D5 BC 48 E0 B0 6B A0 A3 76 2E C4` |

### Large Messages (Tree Hashing)

| Message Length | Output (32 bytes) |
|----------------|-------------------|
| 8191 bytes (ptn) | `1B 57 76 36 F7 23 64 3E 99 0C C7 D6 A6 59 83 74 36 FD 6A 10 36 26 60 0E B8 30 1C D1 DB E5 53 D6` |
| 8192 bytes (ptn) | `48 F2 56 F6 77 2F 9E DF B6 A8 B6 61 EC 92 DC 93 B9 5E BD 05 A0 8A 17 B3 9A E3 49 08 70 C9 26 C3` |

---

## KT256

### Empty Message, Empty Customization
- **Output (64 bytes):**   `B2 3D 2E 9C EA 9F 49 04 E0 2B EC 06 81 7F C1 0C E3 8C E8 E9 3E F4 C8 9E 65 37 07 6A F8 64 64 04 E3 E8 B6 81 07 B8 83 3A 5D 30 49 0A A3 34 82 35 3F D4 AD C7 14 8E CB 78 28 55 00 3A AE BD E4 A9`

### Pattern Message (ptn(n)), Empty Customization

| Message Length | Output (64 bytes) |
|----------------|-------------------|
| 1 byte       | `0D 00 5A 19 40 85 36 02 17 12 8C F1 7F 91 E1 F7 13 14 EF A5 56 45 39 D4 44 91 2E 34 37 EF A1 7F 82 DB 6F 6F FE 76 E7 81 EA A0 68 BC E0 1F 2B BF 81 EA CB 98 3D 72 30 F2 FB 02 83 4A 21 B1 DD D0` |
| 17 bytes       | `1B A3 C0 2B 1F C5 14 47 4F 06 C8 97 99 78 A9 05 6C 84 83 F4 A1 B6 3D 0D CC EF E3 A2 8A 2F 32 3E 1C DC CA 40 EB F0 06 AC 76 EF 03 97 15 23 46 83 7B 12 77 D3 E7 FA A9 C9 65 3B 19 07 50 98 52 7B` |

### Messages with Customization

| Message | Customization | Output (64 bytes) |
|---------|---------------|-------------------|
| Empty   | ptn(1)        | `92 80 F5 CC 39 B5 4A 5A 59 4E C6 3D E0 BB 99 37 1E 46 09 D4 4B F8 45 C2 F5 B8 C3 16 D7 2B 15 98 11 F7 48 F2 3E 3F AB BE 5C 32 26 EC 96 C6 21 86 DF 2D 33 E9 DF 74 C5 06 9C EE CB B4 DD 10 EF F6` |
